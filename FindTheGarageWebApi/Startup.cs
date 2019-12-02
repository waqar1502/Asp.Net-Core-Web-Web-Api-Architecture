using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Autofac;
using App.Services;
using Autofac.Extensions.DependencyInjection;
using App.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using App.Services.Helpers;
using Microsoft.AspNetCore.Http.Features;
using FindTheGarageWebApi.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using FindTheGarageWebApi.ActionFilters;

namespace FindTheGarageWebApi
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA253sgsfhyGbMRdRl1PVkH";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddDbContext<App.DataAccess.DbModels.FindTheGarageContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("FindTheGarageEntities")
                     ));

            // CONFIGURING IDENTITY
            ////services.AddIdentityCore<App.DataAccess.Identity.AspNetUsers>(options =>
            ////{
            ////    options.Password.RequiredLength = 8;
            ////    options.Password.RequireLowercase = false;
            ////    options.Password.RequireUppercase = false;
            ////    options.Password.RequireNonAlphanumeric = false;
            ////    options.Password.RequireDigit = false;
            ////})
            ////.AddDefaultTokenProviders()
            ////    .AddDefaultUI(UIFramework.Bootstrap4)
            ////    .AddEntityFrameworkStores<FindTheGarageContext>();

            services.AddIdentity<App.DataAccess.Identity.AspNetUsers,  App.DataAccess.Identity.AspNetRoles> ()
               .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<App.DataAccess.DbModels.FindTheGarageContext>();

            // Get options from app settings
            IConfigurationSection jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(configureOptions =>
                {
                    configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                    configureOptions.TokenValidationParameters = tokenValidationParameters;
                    configureOptions.SaveToken = true;
                });

            // API USER CLAIM POLICY
            services
                .AddAuthorization(options =>
                {
                    options
                        .AddPolicy(
                        "ApiUser",
                        policy => policy.RequireClaim(
                            Constants.JwtClaimIdentifiersRole,
                            Constants.JwtClaimsApiAccess
                            )
                        );
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
                c.DocumentFilter<EnumDocumentFilter>();
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // REPLACING DEFAULT DI CONTAINER WITH AUTOFAC
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule<AppServiceModule>();
            containerBuilder.RegisterModule<AutoMapperRisgistrationModule>();
            IContainer container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseMiddleware<ExceptionHandling>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
