using AutoMapper;
using DTOS.DTOS.RatingDTOS;
using DTOS.DTOS.UserDTOS;
using Entities;
using Entities.Models;
using MVCAPP.DTOS.DTOS;
using MVCAPP.DTOS.CinemaDTOS;
using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.DTOS.ProducerDTOS;
using MVCAPP.Models;
using DTOS.DTOS.CardDTOS;
using DTOS.DTOS.CommentDTOS;
using DTOS.DTOS.FavoriteDTOS;

namespace MVCAPP.BLL
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorToListDTO>();
            CreateMap<ActorToAddDTO, Actor>();
            CreateMap<ActorToUpdateDTO, Actor>();
            CreateMap<Actor, ActorToUpdateDTO>();

            CreateMap<Movie, MovieToListDTO>();
            CreateMap<MovieToListDTO, Movie>();
            CreateMap<MovieToAddDTO, Movie>();
            CreateMap<MovieToUpdateDTO, Movie>();
            CreateMap<Movie, MovieToUpdateDTO>();

            CreateMap<Producer, ProducerToListDTO>();
            CreateMap<ProducerToAddDTO, Producer>();
            CreateMap<ProducerToUpdateDTO, Producer>();

            CreateMap<CinemaToAddDTO, Cinema>();
            CreateMap<Cinema, CinemaToListDTO>();
            CreateMap<CinemaToUpdateDTO, Cinema>();

            CreateMap<ApplicationUser, UserToListDTO>();
            CreateMap<UserToAddDTO, ApplicationUser>();
            CreateMap<UserToUpdateDTO, ApplicationUser>();

            CreateMap<Rating, RatingToListDTO>();   
            CreateMap<RatingToAddDTO, Rating>();

            CreateMap<CardToAddDTO, Card>();

            CreateMap<Comment, CommentToListDTO>();
            CreateMap<CommentToAddDTO, Comment>();
            CreateMap<CommentToUpdateDTO, Comment>();

            CreateMap<Favorite, FavoriteToListDTO>();
            CreateMap<FavoriteToAddDTO, Favorite>();

        }
    }
}
