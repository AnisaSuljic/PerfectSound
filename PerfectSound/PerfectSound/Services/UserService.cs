using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using PerfectSound.Database;
using PerfectSound.Helper;
using PerfectSound.Interfaces;
using PerfectSound.Model.Requests;
using PerfectSound.Model.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Services
{
    public class UserService : IUserService
    {
        public PerfectSoundContext _context { get; }
        public IMapper _mapper { get; }
        public UserService(PerfectSoundContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public List<Model.Model.User> Get(UserSearchRequest search)
        {
            var query = _context.Users.Include(x => x.UserType).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.UserName))
            {
                query = query.Where(x => x.UserName.ToLower().StartsWith(search.UserName.ToLower()));
            }

            if (search?.UserTypeId != null && search?.UserTypeId != 0)
            {
                query = query.Where(x => x.UserTypeId == search.UserTypeId);
            }

            return _mapper.Map<List<Model.Model.User>>(query.ToList());
        }

        public Model.Model.User GetById(int Id)
        {
            var entity = _context.Users.Find(Id);

            return _mapper.Map<Model.Model.User>(entity);
        }

        public Model.Model.User Insert(UserUpsertRequest request)
        {
            var entity = _mapper.Map<Database.User>(request);

            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Password and password confirm not matched");
            }

            entity.PasswordSalt = PasswordHash.GenerateSalt();
            entity.PasswordHash = PasswordHash.GenerateHash(entity.PasswordSalt, request.Password);

            _context.Users.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Model.User>(entity);
        }

        public Model.Model.User Update(int Id, UserUpsertRequest request)
        {
            var entity = _context.Users.Find(Id);
            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Password and password confirm not matched");
            }

            if (request.Password != null)
            {
                entity.PasswordSalt = PasswordHash.GenerateSalt();
                entity.PasswordHash = PasswordHash.GenerateHash(entity.PasswordSalt, request.Password);
            }
            else
            {
                throw new Exception("Password is required field!");
            }
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Model.User>(entity);
        }
        public Model.Model.User Delete(int Id)
        {
            var entity = _context.Users.Find(Id);
            if (entity == null)
                throw new ArgumentNullException();
            var x = entity;
            _context.Users.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Model.User>(x);
        }

        public async Task<Model.Model.User> Login(string username, string password)
        {
            var entity = await _context.Users.Include(u=>u.UserType).FirstOrDefaultAsync(x => x.UserName == username);

            if (entity == null)
                throw new UserException("Invalid username or password.");

            var hash = PasswordHash.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
                throw new UserException("Invalid username or password.");

            return _mapper.Map<Model.Model.User>(entity);
        }
    }
}
