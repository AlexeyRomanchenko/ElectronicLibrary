import React, {useState} from 'react';
import {Chip} from '@material-ui/core';
import {Done} from '@material-ui/icons';
import { ResponsiveDialog } from '../responsive-dialog';
import { withProps } from '../../../hocs/withProps';

export const ChipsBlock = ({chips=[], header, form, setItem}) => {
    const [isOpen, setDialogStatus] = useState(false);
    const [selectedItem, setSelectedItem] = useState(null);
    
    const closeDialogWindow = () => {
        setDialogStatus(false);
    }
    return (
        <div>
            <h4>{header}</h4>
            {
                chips.map(item => (
                    <Chip key={item.id}
                     clickable 
                     label={item.label} 
                     variant="outlined"
                     onClick={()=> {
                         setSelectedItem(item);
                         setItem(item)
                        }}
                     deleteIcon={<Done />}/>))
            }
             <Chip
                label="+"
                onClick={()=> {
                    setDialogStatus(true);
                }}
                variant="outlined"
      />
            <p>You have chosen: {selectedItem?.label}</p>
            <ResponsiveDialog isOpen={isOpen} form={withProps(form,closeDialogWindow )}/>
        </div>
    );
}