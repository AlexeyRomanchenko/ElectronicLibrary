import React from 'react';
import styles from './CommentForm.module.css';
import { TextField, Button } from '@material-ui/core';
export const CommentForm = () => {
    return (<form>
      <div className={styles.comment__textarea}>
        <TextField variant="outlined" multiline
          rows={4} fullWidth/>
      </div>
        <Button variant="outlined" color="primary">Leave a comment</Button>
    </form>);
}