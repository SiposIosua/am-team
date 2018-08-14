﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebApi.Controllers
{
    public class PlayerController : ApiController
    {
        private PlayerComponent _playerComponent = new PlayerComponent();

        [HttpPost]
        [Route("api/player")]
        public HttpResponseMessage Add([FromBody]PlayerBusinessModel player)
        {
            try
            {
                var result = _playerComponent.Add(player);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("api/players")]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _playerComponent.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("api/player/{playerId}")]
        public HttpResponseMessage Get(int playerId)
        {
            try
            {
                var result = _playerComponent.Get(playerId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex);
            }
     

        }
        [HttpPut]
        [Route("api/player/{playerId}")]
        public HttpResponseMessage Update(int playerId,[FromBody]PlayerBusinessModel player)
        {
            try
            {
                var result = _playerComponent.Update(player);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpDelete]
        [Route("api/player/{playerId}")]
        public HttpResponseMessage Delete(int playerId)
        {
            try
            {
                var result = _playerComponent.Delete(playerId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
