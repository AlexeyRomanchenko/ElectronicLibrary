import { Dialog, DialogContent } from '@material-ui/core';
import useMediaQuery from '@material-ui/core/useMediaQuery';
import { useTheme } from '@material-ui/core/styles';
import React from 'react';
export const ResponsiveDialog = ({form, isOpen }) => {
    const theme = useTheme();
    const fullScreen = useMediaQuery(theme.breakpoints.down('sm'));

    return (<Dialog fullScreen={fullScreen} open={isOpen}>
        <DialogContent>
          {form}
        </DialogContent>
    </Dialog>);
}