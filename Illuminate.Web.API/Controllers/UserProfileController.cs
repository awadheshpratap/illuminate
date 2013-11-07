using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Illuminate.Model.Repository;
using Illuminate.Model;

namespace Illuminate.Web.API.Controllers
{
    public class UserProfileController : ApiController
    {

        private readonly UserProfileRepository _userProfileRepository = new UserProfileRepository();

        // GET api/userprofile
        public IEnumerable<UserProfile> GetAllUsers()
        {
            return _userProfileRepository.Get();
        }

        // GET api/userprofile/<username>
        public UserProfile GetUserDeatailsById(string userid,string password)
        {
            if (userid == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var userProfileInfo = _userProfileRepository.GetByID(userid);
            if (userProfileInfo != null)
            {
                if (!Authenticate(userid, password))
                    return null;
                return userProfileInfo;
            }
            return null;
        }


        // POST api/userprofile/<userId>
        public HttpResponseMessage PostUserProfile(string userId, [FromBody]UserProfile userProfile)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _userProfileRepository.Insert(userProfile);
            }
            else
            {
                _userProfileRepository.Update(userProfile);
            }


            var response = Request.CreateResponse<UserProfile>(HttpStatusCode.Created, userProfile);
            string uri = Url.Link("ConsumeContent", new { contentId = userProfile.UserId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

       
        // DELETE api/userprofile/<userid>
        public void Delete(string userId)
        {
            _userProfileRepository.Delete(userId);
        }

        public bool Authenticate(string user, string passsword)
        {
            return true;
        }
    }
}
