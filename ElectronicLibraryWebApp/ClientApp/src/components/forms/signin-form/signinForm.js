import React from "react";
import { useForm } from "react-hook-form";

export const SignInForm = () => {
  const { register, handleSubmit, watch, errors } = useForm();
  const onSubmit = data => console.log(data);

  console.log(watch("example")) // watch input value by passing the name of it

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input name="username" defaultValue="test" ref={register} />
      <input name="password" ref={register({ required: true })} />
      {errors.password && <span>This field is required</span>}
      
      <input type="submit" />
    </form>
  );
}