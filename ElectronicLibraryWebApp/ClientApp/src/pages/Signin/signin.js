import React from 'react';
import { SignInForm } from '../../components/forms/signin-form';
import styles from './signin.module.css';
export const SignIn = () => {
    return (
    <div className={styles.container}>
        <SignInForm/>
    </div>
    );
}