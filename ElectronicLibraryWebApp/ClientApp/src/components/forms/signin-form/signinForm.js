import { Button } from "@material-ui/core";
import React from "react";
import { useForm } from "react-hook-form";
import TextField from '@material-ui/core/TextField';

export const SignInForm = () => {
  const { register, handleSubmit, watch, errors } = useForm();
  const onSubmit = data => console.log(data);

  console.log(watch("example")) // watch input value by passing the name of it

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <TextField name="username" label="Outlined" variant="outlined" inputRef={register({ required: true })}/>
      <TextField name="parrword" label="Outlined" variant="outlined" inputRef={register({ required: true })}/>
      {errors.password && <span>This field is required</span>}
      
      <Button type="submit" variant="contained" color="primary">Sign in</Button>
    </form>
  );
}