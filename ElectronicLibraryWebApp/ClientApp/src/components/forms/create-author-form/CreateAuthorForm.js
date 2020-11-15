import React from 'react';
import {Button, TextField} from '@material-ui/core';
import styles from './CreateAuthorForm.module.css';

export const CreateAuthorForm = ({handle}) => {

    return (
        <form className={styles.wrapper}>
            <div className={styles.mb2}>
                <TextField name="firstname" variant="outlined" label="firstname" fullWidth/>
            </div>
            <div className={styles.mb2}>
                <TextField name="lastname" variant="outlined" label="lastname" fullWidth/>
            </div>
            <Button onClick={()=> {handle()}} color="primary" variant="contained" fullWidth>Create author</Button>
        </form>
    );
}