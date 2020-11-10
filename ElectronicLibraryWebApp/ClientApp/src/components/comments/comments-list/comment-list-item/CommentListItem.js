import React from 'react';
import styles from './CommentListItem.module.css';

export const CommentListItem = ({comment}) => {
  let commentText= '';
  comment.isBlocked ? commentText = "Comment was blocked by administrator" : commentText = comment.text;
  
  return (
  <div className={styles.comment}>
    <h5>{comment.Theme}</h5>
    <p>{commentText}</p>
  </div>);
}