import React from 'react';
import {Button, TextField} from '@material-ui/core';
import styles from './CreateAuthorForm.module.css';
import axios from 'axios';
import { authors } from '../../../data/authors';

export const CreateAuthorForm = ({handle}) => {
    const onCreate = () => {
        axios({
            method: 'POST',
            url: '/api/author'
        }).then(response=> {
            if(response.status === 200) {
                authors = [...authors]
            }
        });
        handle();
    }
    return (
        <form className={styles.wrapper}>
            <div className={styles.mb2}>
                <TextField name="firstname" variant="outlined" label="firstname" fullWidth/>
            </div>
            <div className={styles.mb2}>
                <TextField name="lastname" variant="outlined" label="lastname" fullWidth/>
            </div>
            <Button onClick={onCreate} color="primary" variant="contained" fullWidth>Create author</Button>
        </form>
    );
}