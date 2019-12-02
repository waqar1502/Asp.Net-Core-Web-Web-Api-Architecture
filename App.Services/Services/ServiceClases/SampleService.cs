using App.DataAccess.DbModels;
using App.Models.ViewModels;
using App.Services.Repositories;
using App.Services.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace App.Services.Services.ServiceClases
{
    public class SampleService : GenericRepository<TestTable> , ISampleService
    {
        #region Properties

        private readonly GenericRepository<TestTable> _repository;
        private readonly IMapper _mapper;

        #endregion
        #region Constructors

        public SampleService(
            
            IMapper mapper
            )
        {
            this._repository = new GenericRepository<TestTable>();
                _mapper = mapper;
        }

        #endregion
        #region Public Methods

        public List<SampleViewModel> GetAllSampleData()
        {
            var dbdata = _repository.GetAll();
            var listData = _mapper.Map<List<SampleViewModel>>(dbdata);
            return listData;
        }

        #endregion
        #region Helpers

        // ADD HERE

        #endregion
    }
}
