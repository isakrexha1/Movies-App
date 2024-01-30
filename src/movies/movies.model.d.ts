export interface movieDTO {
  id: number;
  title: string;
  poster: string;
}
export interface movieCreationDTO {
  title: string;
  inTheaters: boolean;
  trailer: string;
  releaseData?: Date;
  poster?: File;
  posterURL?: string;
  genresIds?: number[];
  movieTheatersIds?: number[];
}

export interface landingPageDTO {
  inTheaters?: movieDTO[];
  upcomingReleases?: movieDTO[];
}
