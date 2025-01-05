using AutoMapper;
using Data.Models;
using Entity;

namespace Services.Mapper
{
    public class BooksMapper : Profile
    {
        public BooksMapper()
        {
            CreateMap<Books, BooksEntity>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString()))
                .ForMember(dest => dest.PublishedYear, opt => opt.MapFrom(src => src.Year.ToString()))
                .ForMember(dest => dest.MLACitation, opt => opt.MapFrom(src => $@"{src.AuthorLastName}, {src.AuthorFirstName}. ""{src.Title}: {src.JournalTitle}"" {src.TitleOfContainer}, {src.Publisher}, {src.Year}, pp. {src.PageNumber}"))
                .ForMember(dest => dest.ChicagoStyleCitation, opt => opt.MapFrom(src => $@"{src.AuthorLastName}, {src.AuthorFirstName}. {src.Year}. ""{src.Title}"". {src.JournalTitle} {src.Volume} ({src.Month} {src.Year}): {src.PageNumber}. {src.URL}"));
            CreateMap<CreateBooksRequest, Books>();
        }
    }
}

