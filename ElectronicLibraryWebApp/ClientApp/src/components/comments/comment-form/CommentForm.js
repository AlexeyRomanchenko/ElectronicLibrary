import React from 'react';
import styles from './CommentForm.module.css';
import { TextField, Button } from '@material-ui/core';
import { useForm } from "react-hook-form";
import axios from 'axios';

export const CommentForm = () => {
  const { register, handleSubmit, errors } = useForm();
  const onSubmit = data => {
    console.log(data);
    data.bookId = 3;
    axios({
      method:'POST',
      url:'/api/comment',
      headers: new Headers({
        'Content-Type':'application/json'
      }),
      data: data
    }).then(response=> {
      console.log(response);
    });
  };
    return (<form onSubmit={handleSubmit(onSubmit)}>
       <div className={styles.comment__input}>
        <TextField variant="outlined" label="Theme"
        name="theme"
        inputRef={register({ required: true })}
         fullWidth/>
        {errors.theme && <span>theme is required</span>}
      </div>

      <div className={styles.comment__textarea}>
        <TextField variant="outlined" label="Message" multiline
        name="text"
        inputRef={register({ required: true })}
          rows={4} fullWidth/>
         {errors.text && <span>text is required</span>}
      </div>

        <Button type="submit" variant="outlined" color="primary">Leave a comment</Button>
    </form>);
}