import { Form, Formik, FormikHelpers } from "formik";
import TextField from "../forms/TextField";
import Button from "../utils/Button";
import { Link } from "react-router-dom";
import { movieTheaterCreationDTO } from "./movieTheater.model";
import * as Yup from "yup";
import Map from "../utils/Map";

export default function MovieTheaterForm(props: movieTheaterForm) {
  return (
    <Formik
      initialValues={props.model}
      onSubmit={props.onSubmit}
      validationSchema={Yup.object({
        name: Yup.string()
          .required("This field is required")
          .firstLetterUppercase(),
      })}
    >
      {(formikProps) => (
        <Form>
          <TextField displayName="Name" field="name" />

          <div style={{ marginBottom: "1rem" }}>
            <Map />
          </div>

          <Button disabled={formikProps.isSubmitting} type="submit">
            Save changes
          </Button>
          <Link className="btn btn secondary" to="/movietheaters">
            Cancel
          </Link>
        </Form>
      )}
    </Formik>
  );
}
interface movieTheaterForm {
  model: movieTheaterCreationDTO;
  onSubmit(
    values: movieTheaterCreationDTO,
    actions: FormikHelpers<movieTheaterCreationDTO>
  ): void;
}
