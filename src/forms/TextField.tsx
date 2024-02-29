import { Field, ErrorMessage } from "formik";

export default function TextField(props :textFieldProps ){
    return(
        <div className="mb-3">
          <label htmlFor={props.field} >{props.displayName}</label>
          <Field type={props.type}
          name={props.field} id={props.field} className="Form-control"></Field>
          <ErrorMessage name={props.field}>{msg => 
          <div className="text-danger">{msg}</div>}</ErrorMessage>
          </div>
    )
}

interface textFieldProps{
    field:  string;
    displayName: string;
    type: 'text' | 'password';
}


TextField.defaultProps = {
    type: 'text'
}