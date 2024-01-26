import React, { useEffect, useState } from 'react';
import './App.css';
import IndividualMovie from './movies/IndividualMovie';
import { landingPageDTO } from './movies/movies.model';
import MoviesList from './movies/MoviesList';


function App() {

  const [movies, setMovies] = useState <landingPageDTO>({});

    useEffect(() => {
      const timerId = setTimeout(() => {
        setMovies({
          inTheaters: [
          {
            id:1,
            title: "Taken",
            poster: 'https://lumiere-a.akamaihd.net/v1/images/image_efeee89d.jpeg?region=0%2C0%2C800%2C1200'
          },
        
          {
            id:2,
            title: "Avengers: Age of Ultron",
            poster: 'https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg'
          }
        ],

        upcomingReleases: [
          {
            id: 3,
            title: 'Family Plan',
            poster: 'https://m.media-amazon.com/images/M/MV5BNGY3ZGNmZGMtNzBhNi00Y2U5LWI3ZTgtMjM4NDk3MjA1MDQ5XkEyXkFqcGdeQXVyNjE2MzI5ODM@._V1_.jpg'
          }
        ]
        })
      }, 200);
      
      return () => clearTimeout(timerId);
    });


  return(

    <div className="container">
      <h3>In Theaters</h3>
      <MoviesList movies={movies.inTheaters}/>

      <h3>Upcoming Releases</h3>
      <MoviesList movies={movies.upcomingReleases}/>
    </div>
  )
}

export default App;
