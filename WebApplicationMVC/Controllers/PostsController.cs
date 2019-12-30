using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

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
        public ActionResult Create(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _postRepository.AddPost(post);
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