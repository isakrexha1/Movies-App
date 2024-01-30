import MovieTheaterForm from "./MovieTheaterForm";

export default function EditMovieTheater() {
  return (
    <>
      <div>Edit Movie Theater</div>
      <MovieTheaterForm
        model={{ name: "Sambil" }}
        onSubmit={(values) => console.log(values)}
      />
    </>
  );
}
