import React from 'react';
import { Button } from "@material-ui/core";
import styles from './signUpForm.module.css';
import { useForm } from "react-hook-form";
import TextField from '@material-ui/core/TextField';

export const SignUpForm = () => {
 const { register, handleSubmit, errors } = useForm();
  const onSubmit = data => console.log(data);
  return (
    <form className={styles.form} onSubmit={handleSubmit(onSubmit)}>
      <div className={styles.form__field__wrapper}>
        <TextField className={styles.form__input} name="username" label="Login" variant="outlined" inputRef={register({ required: true })}/>
        {errors.username && <span>This field is required</span>}
      </div>
      <div className={styles.form__field__wrapper}>
        <TextField className={styles.form__input} name="password" type="password" label="Password" variant="outlined" inputRef={register({ required: true })}/>
        {errors.password && <span>This field is required</span>}
      </div>
       <div className={styles.form__field__wrapper}>
        <TextField className={styles.form__input} name="confirmPassword" type="password" label="Confirm password" variant="outlined" inputRef={register({ required: true })}/>
        {errors.password && <span>This field is required</span>}
      </div>
      <Button className={styles.form__btn} type="submit" variant="contained" color="primary">Sign in</Button>
    </form>
  )
}