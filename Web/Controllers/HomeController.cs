using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexSetting()
        {
            return View();
        }

        public ActionResult PhotoIndex()
        {
            return View();
        }

        public ActionResult PhotoSetting()
        {
            return View();
        }

        /// <summary>
        /// Gets the small set list.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/14
        /// 描述：获取小抽奖列表
        [HttpPost]
        public string GetSmallSetList()
        {
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                var list = (from a in entitys.SmallSets select a).Where(a => a.num != 0).ToList();
                return JsonHelper.GetJson(list);
            }
        }

        /// <summary>
        /// Subs the small.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/18
        /// 描述：减去一个奖品数量
        [HttpPost]
        public string SubtractSmall(int id)
        {
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                try
                {
                    List<Models.SmallSet> list = entitys.SmallSets.Where(a => a.id == id).ToList();
                    if (list.Count > 0)
                    {
                        SmallSet ss = list[0];
                        ss.num = ss.num - 1;
                        entitys.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    return JsonHelper.GetJson("false");
                }
                return JsonHelper.GetJson("true");
            }
        }

        /// <summary>
        /// Inserts the small set.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/14
        /// 描述：插入一个小抽奖
        [HttpPost]
        public string InsertSmallSet(string name, int num, string color)
        {
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                try
                {
                    SmallSet ss = new SmallSet();
                    ss.name = name;
                    ss.num = num;
                    ss.color = color;
                    entitys.SmallSets.Add(ss);
                    entitys.SaveChanges();
                }
                catch (Exception)
                {
                    return JsonHelper.GetJson("false");
                }
                return JsonHelper.GetJson("true");
            }
        }

        /// <summary>
        /// Deletes the small set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/14
        /// 描述：删除奖品
        public string DelSmallSet(int id)
        {
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                try
                {
                    List<Models.SmallSet> list = entitys.SmallSets.Where(a => a.id == id).ToList();
                    if (list.Count > 0)
                    {
                        SmallSet ss = list[0];
                        entitys.SmallSets.Remove(ss);
                        entitys.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    return JsonHelper.GetJson("false");
                }
                return JsonHelper.GetJson("true");
            }
        }

        /// <summary>
        /// Gets the Photo set list.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/14
        /// 描述：获取照片抽奖列表
        [HttpPost]
        public string GetPhotoSetList()
        {
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                var list = (from a in entitys.PhotoSets select a).ToList();
                return JsonHelper.GetJson(list);
            }
        }

        /// <summary>
        /// Inserts the Photo set.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/14
        /// 描述：插入一个照片
        [HttpPost]
        public string InsertPhotoSet(string name, string path, int x, int y, int x2, int y2)
        {
            Bitmap bm = new Bitmap(System.Web.HttpContext.Current.Server.MapPath(path));
            Bitmap bmpOut = new Bitmap(x2-x, y2-y, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmpOut);
            g.DrawImage(bm, new Rectangle(0, 0, x2-x, y2-y), new Rectangle(x, y, x2-x, y2-y), GraphicsUnit.Pixel);
            Random rnd = new Random();
            int num = rnd.Next(5000, 1000000);
            string newpath = "/Data/" + num.ToString() + ".jpg";
            bmpOut.Save(System.Web.HttpContext.Current.Server.MapPath(newpath));
            g.Dispose();  
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                try
                {
                    PhotoSet ss = new PhotoSet();
                    ss.name = name;
                    ss.url = newpath;
                    entitys.PhotoSets.Add(ss);
                    entitys.SaveChanges();
                }
                catch (Exception)
                {
                    return JsonHelper.GetJson("false");
                }
                return JsonHelper.GetJson("true");
            }
            //HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //if (files.Count > 0)
            //{
            //    Random rnd = new Random();
            //    string path = "";
            //    HttpPostedFile file = files[0];
            //    if (file.ContentLength > 0)
            //    {
            //        string fileName = file.FileName;
            //        string extension = Path.GetExtension(fileName);
            //        int num = rnd.Next(5000, 1000000);
            //        path = "/Data/" + num.ToString() + extension;
            //        file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));
            //    }
            //    using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            //    {
            //        try
            //        {
            //            PhotoSet ss = new PhotoSet();
            //            ss.name = name;
            //            ss.url = path;
            //            entitys.PhotoSets.Add(ss);
            //            entitys.SaveChanges();
            //        }
            //        catch (Exception)
            //        {
            //            return JsonHelper.GetJson("false");
            //        }
            //        return JsonHelper.GetJson("true");
            //    }
            //}
            //else
            //{
            //    return JsonHelper.GetJson("false");
            //}
        }

        /// <summary>
        /// Inserts the photo.
        /// </summary>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/20
        /// 描述：上传一张图片
        [HttpPost]
        public string InsertPhoto()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            if (files.Count > 0)
            {
                Random rnd = new Random();
                string path = "";
                HttpPostedFile file = files[0];
                if (file.ContentLength > 0)
                {
                    string fileName = file.FileName;
                    string extension = Path.GetExtension(fileName);
                    int num = rnd.Next(5000, 1000000);
                    path = "/Data/" + num.ToString() + extension;
                    file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));
                }
                return path;
            }
            else
            {
                return JsonHelper.GetJson("false");
            }
        }

        /// <summary>
        /// Deletes the Photo set.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2016/1/14
        /// 描述：删除照片
        public string DelPhotoSet(int id)
        {
            using (LuckyDrawEntities entitys = new LuckyDrawEntities())
            {
                try
                {
                    List<Models.PhotoSet> list = entitys.PhotoSets.Where(a => a.id == id).ToList();
                    if (list.Count > 0)
                    {
                        PhotoSet ss = list[0];
                        entitys.PhotoSets.Remove(ss);
                        entitys.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    return JsonHelper.GetJson("false");
                }
                return JsonHelper.GetJson("true");
            }
        }
    }
}
