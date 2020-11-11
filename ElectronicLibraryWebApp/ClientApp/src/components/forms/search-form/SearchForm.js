import React from 'react';
import InputBase from '@material-ui/core/InputBase';
import styles from './SearchForm.module.css';

export const SearchForm = ({onSearch}) => {
    return (
        <InputBase
            onChange={onSearch}
        className={styles.search_bar}
        placeholder="Search books"
        inputProps={{ 'aria-label': 'search google maps' }}
      />
    );
}