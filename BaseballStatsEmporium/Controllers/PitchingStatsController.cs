using BaseballStats.Data;
using BaseballStats.Data.Entity;
using BaseballStatsEmporium.Composers.Infrastructure;
using BaseballStatsEmporium.ModelParameters;
using BaseballStatsEmporium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BaseballStatsEmporium.Controllers
{
    public class PitchingStatsController : Controller
    {
        private IComposer composer;

        public PitchingStatsController(IComposer composer)
        {
            this.composer = composer;
        }

        public ActionResult Index()
        {
            var players = composer.Compose<List<PlayerInformation>>().UsingParameters<PlayerInformationParameters>(new PlayerInformationParameters());
            return View();
        }

    }
}
