import { Button, TextField } from '@material-ui/core';
import React from 'react';
import styles from './CreateGenreForm.module.css';

export const CreateGenreForm = ({handle}) => {
    return (
        <form className={styles.wrapper}>
            <div className={styles.mb2}>
                <TextField variant="outlined" name="name" label="Genre name" fullWidth/>
            </div>
            <Button  color="primary" variant="contained" onClick={()=> {handle()}} fullWidth>Create genre</Button>
        </form>
    );
}