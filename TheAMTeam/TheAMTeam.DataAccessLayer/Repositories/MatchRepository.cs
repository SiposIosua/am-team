﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;


namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class MatchRepository
    {
        public Match Add(Match match)
        {
            Match dbMatch;
            try
            {
                using (var context = new AppContext())
                {
                    dbMatch = context.Matches.Add(match);
                    context.SaveChanges();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbMatch;
        }

        public Match GetById(int id)
        {
            Match idMatch;
            try
            {
                using (var context = new AppContext())
                {
                    idMatch = context.Matches.Where(m => m.MatchId == id).SingleOrDefault();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return idMatch;
        }

        public Match Update(Match match)
        {
            //Match dbMatch;
            try
            {
                using (var context = new AppContext())
                {
                    // case 1
                    //dbMatch = context.Matches.Find(match.MatchesId);
                    //if(dbMatch != null)
                    //{
                    //    dbMatch.FirstTeamId = match.FirstTeamId;
                    //    dbMatch.SecondTeamId = match.SecondTeamId;
                    //    dbMatch.FirstTeamScore = match.FirstTeamScore;
                    //    dbMatch.Match_date = match.Match_date;
                    //    dbMatch.CompId = match.CompId;
                    //}

                    //case 2
                    if (match != null)
                    {
                        context.Matches.Attach(match);
                        context.Entry(match).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            //return dbMatch;
            return match;
        }

        public bool Delete(int id)
        {
            Match dbMatch;
            try
            {
                using (var context = new AppContext())
                {
                    dbMatch = context.Matches.Where(m => m.MatchId == id).SingleOrDefault();
                    context.Matches.Remove(dbMatch);
                    context.SaveChanges();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbMatch != null ? true : false;
        }

                // var 1
        //public IQueryable<Match> getAll()
        //{
        //    using (var context =  new AMTeamEntities())
        //    {
        //        return context.Set<Match>();
        //    } 
        //}

        //var 2
        public List<Match> getAll()
        {
            List<Match> matches;
            try
            {
                using (var context = new AppContext())
                {
                    matches = context.Matches.ToList();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return matches;
        }
    }
}