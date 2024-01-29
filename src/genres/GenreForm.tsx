import { Form, Formik, FormikHelpers } from "formik";
import { Link } from "react-router-dom";
import Button from "../utils/Button";
import * as YUP from "yup";
import TextField from "../forms/TextField";
import { genresCreationDTO } from "./genres.model";

export default function GenreForm(props: genreFromProps) {
  return (
    <Formik
      initialValues={props.model}
      onSubmit={props.onSubmit}
      validationSchema={YUP.object({
        name: YUP.string()
          .required("This field is required")
          .firstLetterUppercase(),
      })}
    >
      {(formikProps) => (
        <Form>
          <TextField field="name" displayName="Name" />
          <Button disabled={formikProps.isSubmitting} type="submit">
            Save Changes
          </Button>
          <Link className="btn btn-secondary" to="/genres">
            Cancel
          </Link>
        </Form>
      )}
    </Formik>
  );
}

interface genreFromProps {
  model: genresCreationDTO;
  onSubmit(
    values: genresCreationDTO,
    action: FormikHelpers<genresCreationDTO>
  ): void;
}
