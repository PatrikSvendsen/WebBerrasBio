﻿using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieModel> GetMovies();
    }
}