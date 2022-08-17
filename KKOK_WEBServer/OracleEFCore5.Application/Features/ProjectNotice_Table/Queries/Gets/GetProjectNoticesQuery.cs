﻿using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    public class GetProjectNoticesQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public int Pjt_Code { get; set; }

        public int Member_Code { get; set; }

        public int Notice_Code { get; set; }

        public string Member_Name { get; set; }

        public DateTime Notice_Date { get; set; }

        public string Notice_Name { get; set; }

        public string Notice_Description { get; set; }

    }

    public class GetAllProjectNoticesQueryHandler : IRequestHandler<GetProjectNoticesQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IProjectNoticeRepositoryAsync _projectnoticeRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllProjectNoticesQueryHandler(IProjectNoticeRepositoryAsync projectnoticeRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _projectnoticeRepository = projectnoticeRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProjectNoticesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<ProjectNoticesData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<ProjectNoticesData>();
            }
            // query based on filter
            var entitymembers = await _projectnoticeRepository.GetPagedProjectNoticeReponseAsync(validFilter);
            var data = entitymembers.data;
            RecordsCount recordCount = entitymembers.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
