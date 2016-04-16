﻿using System;
using System.Collections.Generic;
using System.Linq;
using Web.Model;
using Microsoft.AspNet.Mvc;
using Bookmarks5.Common;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private ITagRepository tagRepository;

        public TagsController(ITagRepository tagRepo)
        {
            tagRepository = tagRepo;
        }

        // GET: api/tags
        [HttpPost("CalculateMostFreqTerms")]
        public IEnumerable<string> CalculateMostFreqTerms([FromBody]TagBundleRequest tagBundle)
        {
            return @"cryptography
                    encryption
                    ssl
                    tor                    
                    https".Split(new char[] { '\n' }).Select(t => t.Trim());
        }

        [HttpPost("CalculateAssociatedTerms")]
        public IEnumerable<string> CalculateAssociatedTerms(
            [FromBody]TagBundleRequest tagBundle)
        {
            return new string[] { "stub1", "stub2" };
        }

        [HttpGet("GetTagBundle")]
        public IEnumerable<string> GetTagBundle(
            [FromQuery]string bundleName, [FromQuery]string bookmarksCollectionName)
        {
            return new string[] { "tst1", "tst2", "tst3", "tst4" };
        }

        [HttpGet("GetTagBundles")]
        public IEnumerable<string> GetTagBundles(
            [FromQuery]string bookmarksCollectionName)
        {
            return new string[] { "cryptography", "security", "machine-learning", "tools", "linux" };
        }

        [HttpGet("GetExcludeList")]
        public IEnumerable<string> GetExcludeList(
            [FromQuery]string bundleName)
        {
            return new string[] { "books", "!torontopubliclibrary","papers","!filetype:pdf","paper" };
        }

        [HttpPost("SaveTagBundle")]
        public void SaveTagBundle(
           [FromBody]TagBundleRequest tagBundle)
        {
            #region Null Checks
            if (string.IsNullOrEmpty(tagBundle?.BookmarksCollectionName))
            {
                throw new ArgumentException("tagBundle?.BookmarksCollectionName");
            }

            if (string.IsNullOrEmpty(tagBundle?.BundleName))
            {
                throw new ArgumentException("tagBundle?.BundleName");
            }

            if (tagBundle.TagBundle == null && tagBundle.TagBundle.Count() == 0)
            {
                throw new ArgumentException("tagBundle.ExcludeList is null or empty");
            }
            #endregion
            //TODO: add service call here
        }

        [HttpPost("CreateTagBundle")]
        public void CreateTagBundle(
           [FromBody]TagBundleRequest tagBundle)
        {
            #region Null Checks
            if (string.IsNullOrEmpty(tagBundle?.BookmarksCollectionName))
            {
                throw new ArgumentException("tagBundle?.BookmarksCollectionName");
            }

            if (string.IsNullOrEmpty(tagBundle?.BundleName))
            {
                throw new ArgumentException("tagBundle?.BundleName");
            }
            #endregion
            //TODO: add service call here
        }

        [HttpPost("SaveExcludeList")]
        public void SaveExcludeList(
           [FromBody]TagBundleRequest tagBundle)
        {
            #region Null Checks
            if (string.IsNullOrEmpty(tagBundle?.BookmarksCollectionName))
            {
                throw new ArgumentException("tagBundle?.BookmarksCollectionName");
            }

            if(string.IsNullOrEmpty(tagBundle?.BundleName))
            {
                throw new ArgumentException("tagBundle?.BundleName");
            }

            if (tagBundle.ExcludeList == null && tagBundle.ExcludeList.Count() == 0)
            {
                throw new ArgumentException("tagBundle.ExcludeList is null or empty");
            }
            #endregion

            //TODO: add service call here
        }

        [HttpGet("GetBookmarkCollections")]
        public IEnumerable<string> GetBookmarkCollections()
        {
            var result = new List<string> { "delicious", "bibsonomy", "pinterest" };
            //TODO: add service call here
            return result;
        }

        [HttpGet("SetDefaultBookmarkCollection")]
        public void SetDefaultBookmarkCollection()
        {
            //TODO: add service call here
        }

        //bookmarks load functionality should be moved to separate ETL project
        //[HttpPost("uploadBookmarksFile")]
        //public async Task<JsonResult> UploadBookmarksFile()
        //{
        //    var file = Request.Form.Files.FirstOrDefault();
        //    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
        //    await ProcessBookmarksFile(file, fileName.Replace("\"", ""));

        //    return Json(new string[0]);
        //}

        //private async Task ProcessBookmarksFile(IFormFile file, string name)
        //{
        //    #region null checks
        //    if (file == null || file.Length > 12000000)
        //    {
        //        throw new ArgumentException("stream");
        //    }

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        throw new ArgumentException("name");
        //    }
        //    #endregion

        //    byte[] result;
        //    using (var stream = file.OpenReadStream())
        //    {
        //        result = new byte[stream.Length];
        //        await stream.ReadAsync(result, 0, (int)stream.Length);
        //    }

        //    var content = System.Text.Encoding.UTF8.GetString(result);
        //    //TODO: call parser here
        //}
    }
}