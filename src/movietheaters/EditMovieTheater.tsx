import MovieTheaterForm from "./MovieTheaterForm";

export default function EditMovieTheater() {
  return (
    <>
      <div>Edit Movie Theater</div>
      <MovieTheaterForm
        model={{
          name: "Sambil",
          latitude: 18.482523328860523,
          longitude: -69.91510391235353,
        }}
        onSubmit={(values) => console.log(values)}
      />
    </>
  );
}
