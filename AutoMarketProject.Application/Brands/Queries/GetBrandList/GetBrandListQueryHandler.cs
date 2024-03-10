using AutoMapper;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Presentation.Brands;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Brands.Queries.GetBrandList;

public class GetBrandListQueryHandler : IQueryHandler<GetBrandListQuery, PagedList<BrandDto>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetBrandListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<BrandDto>>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllUsePagination(request.BrandParameters, cancellationToken);

        var brandsDto = _mapper.Map<PagedList<BrandDto>>(brands);

        return brandsDto;
    }
}