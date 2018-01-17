using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ResultatService.Models;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace ResultatService.Controllers
{
    [EnableCors(origins: "http://resultatservice.azurewebsites.net", headers: "*", methods: "*")]
    public class FixturesController : ApiController
    {
        private dbAppEntities db = new dbAppEntities();

        // GET: api/Fixtures
        public IQueryable<Fixtures> GetFixtures(DateTime StartDatum)
        //public string GetFixtures(DateTime StartDatum)
        {
            string svar;
            DateTime datum = StartDatum;
            datum = StartDatum.AddDays(1);
            var ResultatIdag = from a in db.Fixtures
                                    where a.Date >= StartDatum
                                    where a.Date <= datum
                                    select a;
            //return db.Fixtures;
            return ResultatIdag;
            /*List<Fixtures> F = new List<Fixtures>();

            foreach (var item in ResultatIdag)
            {
                Fixtures f = new Fixtures();
                svar = Test(item.AwayGoalDetails);
                if (svar == "S")
                {
                    f.AwayGoalDetails = item.AwayGoalDetails.Trim();
                }
                else f.AwayGoalDetails = "-";
                f.AwayGoals = item.AwayGoals;
                svar = Test(item.AwayLineupDefense);
                if (svar == "S")
                {
                    f.AwayLineupDefense = item.AwayLineupDefense.Trim();
                }
                else f.AwayLineupDefense = "-";
                svar = Test(item.AwayLineupForward);
                if (svar == "S")
                {
                    f.AwayLineupForward = item.AwayLineupForward.Trim();
                }
                else f.AwayLineupForward = "-";
                svar = Test(item.AwayLineupGoalkeeper);
                if (svar == "S")
                {
                    f.AwayLineupGoalkeeper = item.AwayLineupGoalkeeper.Trim();
                }
                else f.AwayLineupGoalkeeper = "-";
                svar = Test(item.AwayLineupMidfield);
                if (svar == "S")
                {
                    f.AwayLineupMidfield = item.AwayLineupMidfield.Trim();
                }
                else f.AwayLineupMidfield = "-";
                svar = Test(item.AwayLineupSubstitutes);
                if (svar == "S")
                {
                    f.AwayLineupSubstitutes = item.AwayLineupSubstitutes.Trim();
                }
                else f.AwayLineupSubstitutes = "-";
                
                f.AwayTeam = item.AwayTeam.Trim();
                svar = Test(item.AwayTeamRedCardDetails);
                if (svar == "S")
                {
                    f.AwayTeamRedCardDetails = item.AwayTeamRedCardDetails.Trim();
                }
                else f.AwayTeamRedCardDetails = "-";
                svar = Test(item.AwayTeamYellowCardDetails);
                if (svar == "S")
                {
                    f.AwayTeamYellowCardDetails = item.AwayTeamYellowCardDetails.Trim();
                }
                else f.AwayTeamYellowCardDetails = "-";

                f.AwayTeam_Id = item.AwayTeam_Id.Trim();
                f.Date = item.Date;
                svar = Test(item.HomeGoalDetails);
                if (svar == "S")
                {
                    f.HomeGoalDetails = item.HomeGoalDetails.Trim();
                }
                else f.HomeGoalDetails = "-";

                f.HomeGoals = item.HomeGoals;
                svar = Test(item.HomeLineupDefense);
                if (svar == "S")
                {
                    f.HomeLineupDefense = item.HomeLineupDefense.Trim();
                }
                else f.HomeLineupDefense = "-";
                svar = Test(item.HomeLineupForward);
                if (svar == "S")
                {
                    f.HomeLineupForward = item.HomeLineupForward.Trim();
                }
                else f.HomeLineupForward = "-";
                svar = Test(item.HomeLineupGoalkeeper);
                if (svar == "S")
                {
                    f.HomeLineupGoalkeeper = item.HomeLineupGoalkeeper.Trim();
                }
                else f.HomeLineupGoalkeeper = "-";
                svar = Test(item.HomeLineupMidfield);
                if (svar == "S")
                {
                    f.HomeLineupMidfield = item.HomeLineupMidfield.Trim();
                }
                else f.HomeLineupMidfield = "-";
                svar = Test(item.HomeLineupMidfield);
                if (svar == "S")
                {
                    f.HomeLineupMidfield = item.HomeLineupMidfield.Trim();
                }
                else f.HomeLineupMidfield = "-";
                svar = Test(item.HomeLineupSubstitutes);
                if (svar == "S")
                {
                    f.HomeLineupSubstitutes = item.HomeLineupSubstitutes.Trim();
                }
                else f.HomeLineupSubstitutes = "-";
                svar = Test(item.HomeTeamRedCardDetails);
                if (svar == "S")
                {
                    f.HomeTeamRedCardDetails = item.HomeTeamRedCardDetails.Trim();
                }
                else f.HomeTeamRedCardDetails = "-";
                svar = Test(item.HomeTeam);
                if(svar == "S")
                {
                    f.HomeTeam = item.HomeTeam.Trim();
                }
                else f.HomeTeam = "-";
                svar = Test(item.HomeTeamYellowCardDetails);
                if (svar == "S")
                {
                    f.HomeTeamYellowCardDetails = item.HomeTeamYellowCardDetails.Trim();
                }
                else f.HomeTeamYellowCardDetails = "-";

                f.HomeTeam_Id = item.HomeTeam_Id;
                f.Id = item.Id;
                f.Idnr = item.Idnr;
                svar = Test(item.League);
                if (svar == "S")
                {
                    f.League = item.League.Trim();
                }
                else f.League = "-";
                svar = Test(item.Location);
                if (svar == "S")
                {
                    f.Location = item.Location.Trim();
                }
                else f.Location = "-";
                svar = Test(item.Time);
                if (svar == "S")
                {
                    f.Time = item.Time.Trim();
                }
                else f.Time = " ";

                F.Add(f);
            }
            string s = JsonConvert.SerializeObject(F);
            return s;*/
        }
        public static String Test(string s)
        {
            if (String.IsNullOrEmpty(s))
                return " ";
            else
                return "S";
        }
        // GET: api/Fixtures/5
        [ResponseType(typeof(Fixtures))]
        public IHttpActionResult GetFixtures(int id)
        {
            Fixtures fixtures = db.Fixtures.Find(id);
            if (fixtures == null)
            {
                return NotFound();
            }

            return Ok(fixtures);
        }

        // PUT: api/Fixtures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFixtures(int id, Fixtures fixtures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fixtures.Idnr)
            {
                return BadRequest();
            }

            db.Entry(fixtures).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixturesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Fixtures
        [ResponseType(typeof(Fixtures))]
        public IHttpActionResult PostFixtures(Fixtures fixtures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fixtures.Add(fixtures);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fixtures.Idnr }, fixtures);
        }

        // DELETE: api/Fixtures/5
        [ResponseType(typeof(Fixtures))]
        public IHttpActionResult DeleteFixtures(int id)
        {
            Fixtures fixtures = db.Fixtures.Find(id);
            if (fixtures == null)
            {
                return NotFound();
            }

            db.Fixtures.Remove(fixtures);
            db.SaveChanges();

            return Ok(fixtures);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FixturesExists(int id)
        {
            return db.Fixtures.Count(e => e.Idnr == id) > 0;
        }
    }
}