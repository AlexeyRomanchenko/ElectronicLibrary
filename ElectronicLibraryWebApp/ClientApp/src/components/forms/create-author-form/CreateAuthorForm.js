import React from 'react';
import { useForm } from 'react-hook-form';
import {Button, TextField} from '@material-ui/core';
import styles from './CreateAuthorForm.module.css';
import axios from 'axios';
import { authors } from '../../../data/authors';

export const CreateAuthorForm = ({ handle }) => {
    const { register, handleSubmit, watch, errors } = useForm();
    const onSubmit = data => console.log(data);

    const onCreate = () => {
        axios({
            method: 'POST',
            url: '/api/author',
            body: ""
        }).then(response=> {
            if(response.status === 200) {
                authors = [...authors]
            }
        });
        handle();
    }
    return (
        <form onSubmit={handleSubmit(onSubmit)} className={styles.wrapper}>
            <div className={styles.mb2}>
                <TextField name="firstname" variant="outlined" label="firstname" inputRef={register({ required: true })} fullWidth />
            </div>
            <div className={styles.mb2}>
                <TextField name="lastname" variant="outlined" label="lastname" inputRef={register({ required: true })} fullWidth/>
            </div>
            <Button onClick={onCreate} color="primary" variant="contained" fullWidth>Create author</Button>
        </form>
    );
}