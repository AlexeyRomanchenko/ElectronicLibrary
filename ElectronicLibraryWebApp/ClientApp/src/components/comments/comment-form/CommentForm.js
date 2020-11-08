import React from 'react';
import styles from './CommentForm';
import { TextField, Button } from '@material-ui/core';
export const CommentForm = () => {
    return (<form>
        <TextField variant="outlined" multiline
          rows={4} fullWidth/>
        <Button variant="outlined" color="primary">Leave a comment</Button>
    </form>);
}