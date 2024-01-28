import { Form, Formik } from "formik";
import { Link } from "react-router-dom";
import Button from "../utils/Button";
import * as YUP from "yup";
import TextField from "../forms/TextField";

export default function CreateGenre() {
  // const history = useHistory();
  return (
    <>
      <h3>Create Genre</h3>

      <Formik
        initialValues={{
          name: "",
        }}
        onSubmit={async (value) => {
          //when the form is posted
          await new Promise((r) => setTimeout(r, 1));
          console.log(value);
        }}
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
    </>
  );
}
