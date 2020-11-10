import React from 'react';
import { CommentListItem } from './comment-list-item';
import styles from './CommentList.module.css'

export const CommentList = ({comments}) => {
  let commentsBlock = "There is no any comments";
  
  if (comments.length > 0 ) {
     commentsBlock = comments.map(comment => {
    return <CommentListItem key={comment.id} comment={comment}/>
  });} 
  
  return (
    <div className={styles.comment__wrapper}>  
      {commentsBlock}
    </div>
  );
}