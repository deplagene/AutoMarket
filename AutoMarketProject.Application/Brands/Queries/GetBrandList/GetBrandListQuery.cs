using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Presentation.Brands;

namespace AutoMarketProject.Application.Brands.Queries.GetBrandList;

public sealed record GetBrandListQuery(BrandParameters BrandParameters) : IQuery<PagedList<BrandDto>>;