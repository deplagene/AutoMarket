using AutoMapper;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Presentation.Brands;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Brands.Queries.GetBrandByName;

public class GetBrandByNameQueryHandler : IQueryHandler<GetBrandByNameQuery, BrandDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetBrandByNameQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<Result<BrandDto>> Handle(GetBrandByNameQuery request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetBrandByName(request.BrandName, cancellationToken);

        if (brand is null)
        {
            return Result.Failure<BrandDto>($"{nameof(brand)} not found");
        }

        var brandDto = _mapper.Map<BrandDto>(brand);

        return brandDto;
    }
}