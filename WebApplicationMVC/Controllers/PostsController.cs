using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;
using WebApplicationMVC.ViewModels;

namespace WebApplicationMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        // GET: Posts
        public ActionResult Index()
        {
            return View(_postRepository.GetAllPosts());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            var post = _postRepository.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //string uploadsFolder = Path.Combine(
                    //    Directory.GetCurrentDirectory(), "wwwroot", "images");
                    //uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    //string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                    string uniqueFileName = null;

                    if (model.Photo != null)
                    {
                        var uploadsFolder = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot", "images");
                        uniqueFileName = Guid.NewGuid() + "_" + model.Photo.FileName;

                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                    var post = new Post
                    {
                        Title = model.Title,
                        CreatorLogin = model.CreatorLogin,
                        Text = model.Text,
                        CreationDate = DateTime.Now,
                        PreviewImagePath = uniqueFileName
                    };

                    _postRepository.AddPost(post);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var post = _postRepository.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _postRepository.UpdatePost(post); 
                }
                else
                {
                    return View(post);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _postRepository.DeletePost(id);

            return RedirectToAction("Index");
        }
    }
}