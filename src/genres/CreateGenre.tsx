import {Form, Formik} from "formik";
import {Link} from "react-router-dom";
import Button from "../utils/Button";
import * as YUP from 'yup';
import TextField from "../forms/TextField";


export default function CreateGenre() {
  // const history = useHistory();
  return (
    <>
      <h3>Create Genre</h3>

      <Formik initialValues={{
        name : ''
      }}
      onSubmit={value =>{
        console.log(value);
      }}
      validationSchema={YUP.object({
        name : YUP.string().required('This field is required')

      })}
      >
        <Form>
          <TextField field="name" displayName="Name"/>
          <Button type="submit">Save Changes</Button>
          <Link className="btn btn-secondary" to="/genres">Cancel</Link>
        </Form>
      </Formik>
      
    </>
  );
}
