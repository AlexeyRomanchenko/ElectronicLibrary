import React, {useState} from 'react';
import styles from './ImageUpload.module.css';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';

export const ImageUpload = ({setImage}) => {
    const [img, setImg] = useState(null); 
    const uploadHandler = (e) => {
        const reader = new FileReader();
        reader.onload = () => {
            if(reader.readyState === 2)
            {
                setImg(reader.result);
                setImage(reader.result);
            }
        }
        reader.readAsDataURL(e.target.files[0]);
    }

    return (
        <div className={styles.wrapper}>
            <div className={styles.image__placeholder} style={{backgroundImage:`url(${img})`}}>
                {/* <img src={img} alt="book"/> */}
            </div>
            <input accept="image/*" className={styles.input} id="icon-button-file" type="file" onChange={uploadHandler}/>
            <label htmlFor="icon-button-file">
                <IconButton color="primary" aria-label="upload picture" component="span">
                <PhotoCamera />
                </IconButton>
            </label>
        </div>
    );
}