﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.ActionResults;
using My_Books.Data.Models;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;
using My_Books.Exceptions;
using System;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _puslishersService;
        public PublishersController(PublishersService puslishersService)
        {
            _puslishersService = puslishersService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var _result = _puslishersService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("add-puslisher")]
        public IActionResult AddPuslisher([FromBody] PublisherVM puslisher)
        {
            try
            {
                var newPublisher = _puslishersService.AddPublisher(puslisher);
                return Created(nameof(AddPuslisher), newPublisher);
            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _puslishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _puslishersService.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _puslishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
