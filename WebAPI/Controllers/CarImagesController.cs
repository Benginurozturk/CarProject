using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public CarImagesController(IWebHostEnvironment webHostEnvironment, ICarImageService carImageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload file)
        {

            string path = _webHostEnvironment.WebRootPath + "\\images\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string imageName = Guid.NewGuid().ToString();
            string fullPath = path + imageName;
            var businessRule = _carImageService.CheckIfImageLimitExceded(file.CarId);
            if (businessRule.Success)
            {
                using (FileStream fs = System.IO.File.Create(fullPath))
                {

                    file.files.CopyTo(fs);
                    fs.Flush();


                }
            }
            CarImage carImage = new CarImage { ImagePath = fullPath, CarId = file.CarId };
            var result = _carImageService.Add(carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm] int id)
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId([FromForm] int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

    }
}

