import { urlMovieTheaters } from "../endpoints";
import EditEntity from "../utils/EditEntity";
import MovieTheaterForm from "./MovieTheaterForm";
import { movieTheaterCreationDTO, movieTheaterDTO } from "./movieTheater.model";

export default function EditMovieTheater() {
  return (
    <EditEntity<movieTheaterCreationDTO, movieTheaterDTO>
      url={urlMovieTheaters}
      indexURL="/movietheaters"
      entityName="Movie Theater"
    >
      {(entity, edit) => (
        <MovieTheaterForm
          model={entity}
          onSubmit={async (values) => await edit(values)}
        />
      )}
    </EditEntity>
  );
}
