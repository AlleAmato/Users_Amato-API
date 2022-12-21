using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UsersApiC.Models;
using System.Data.Entity;
using UsersApiC.Dtos;
using AutoMapper;
using UsersApiC.App_Start;
using AutoMapper.QueryableExtensions;

namespace UsersApiC.Controllers
{
    [RoutePrefix("api/v1/users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("Random")]
        public async Task<UserDto> Random()
        {
            using (var context = new UsersContext())
            {
                /* var user= await context.Users
                     .FirstOrDefaultAsync();

                 var UserDto = new UserDto
                 {   
                     Id = user.Id,
                     LastName = user.LastName,
                     FirstName = user.FirstName,
                     Age = user.Age,
                     Address = user.Address,
                     BirthDate = user.BirthDate,
                     City = user.City,
                     PostalCode = user.PostalCode,
                     Email = user.Email,
                     Username = user.Username,
                     Password = user.Password,
                     Gender = user.Gender,
                     State = user.State,
                     Logins= user.Logins
                     .Select(s=> new LoginDto
                     {
                         Id=s.Id,
                         UserId=s.UserId,
                         Date=s.Date,
                         LoginSuccessful=s.LoginSuccessful,
                         Note=s.Note
                     })
                     .ToList()
                 };
                 return UserDto;*/

                //oppure in modo più compatto
                /*
                 return await context.Users(user=> new UserDto{
                     Id = user.Id,
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        Age = user.Age,
                        Address = user.Address,
                        BirthDate = user.BirthDate,
                        City = user.City,
                        PostalCode = user.PostalCode,
                        Email = user.Email,
                        Username = user.Username,
                        Password = user.Password,
                        Gender = user.Gender,
                        State = user.State,
                        Logins= user.Logins
                        .Select(s=> new LoginDto
                        {
                            Id=s.Id,
                            UserId=s.UserId,
                            Date=s.Date,
                            LoginSuccessful=s.LoginSuccessful,
                            Note=s.Note
                        })
                        .ToList()
                        .FirstOrDefaultAsync();
                */



                //questa soluzione è eccessivamente lunga quindi
                //usiamo automapper (dai pacchetti NuGet)
                //creiamo una classe di configurazione chiamata "DtoMappingProfile" in App_Start

                var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DtoMappingProfilecs>()));

                var user = await context.Users.FirstOrDefaultAsync();
                return mapper.Map<UserDto>(user);//<Tipo di destinazione>
                //nel caso non volessi una delle due tabelle basta non mapparle
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> UsersId(int id)
        {
            using (var context = new UsersContext())
            {
                var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DtoMappingProfilecs>()));
                var retVal = await context.Users
                    .ProjectTo<UserDto>((IConfigurationProvider)mapper)
                    .FirstOrDefaultAsync(q => q.Id == id);
                if (retVal == null) {
                    retVal = 0;
                    return retVal;
                }
                else return retVal;
            }

            [HttpGet]
            [Route("")]
            public async Task<UserDto> UsersList()
            {
                using (var context = new UsersContext())
                {
                    Mapper mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DtoMappingProfilecs>()));
                    var user = await context.Users.ToListAsync();
                    return mapper.Map<UserDto>(user);
                }

            }

            [HttpPost]
            [Route("Add")]
            public void Add([FromBody] UserDto muovo)
            {
                var mapper = new Mapper(mapper);
                var user = mapper.Map<User>(nuovo);
            }
        }
    }
}