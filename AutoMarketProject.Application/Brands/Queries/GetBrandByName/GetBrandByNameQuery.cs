using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Presentation.Brands;

namespace AutoMarketProject.Application.Brands.Queries.GetBrandByName;

public sealed record GetBrandByNameQuery(string BrandName) : IQuery<BrandDto>;