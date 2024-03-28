import { useEffect } from "react"
import { addMember, deleteVaccinations, deleteMember, saveAllMembers, updateMember } from './listOfMembersSlice'
import { useDispatch, useSelector } from 'react-redux'
import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ListItemText from '@mui/material/ListItemText';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import FolderIcon from '@mui/icons-material/Folder';
import DeleteIcon from '@mui/icons-material/Delete';
import './listOfMembers.css'
import Card from "../card/Card";
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import GroupAddIcon from '@mui/icons-material/GroupAdd';


const Demo = styled('div')(({ theme }) => ({
  backgroundColor: theme.palette.background.paper,
}));

export default function ListOfMembers() {

  const [dense, setDense] = React.useState(false);
  let dis = useDispatch();
  const arrMembers = useSelector(s => s.members.allMembers)
  const [member, setMember] = React.useState({})
  const [openCard, setOpenCard] = React.useState(false);

  const handleClose = () => {
    setOpenCard(false);
  };

  const handleClickOpen = (member) => {
    setMember(member)
    setOpenCard(true);
  };

  useEffect(() => {
    dis(saveAllMembers())
  }, [arrMembers])

  const delMember = (id) => {
    dis(deleteMember(id))
    dis(deleteVaccinations(id))
  }

  const addMem = (member) => {
    dis(addMember(member))
  }

  const updateMem = (memberWithId) => {
    dis(updateMember(memberWithId))
  }

  return (<>
    <div className="list" >
      <Dialog open={openCard} onClose={handleClose} PaperProps={{ component: 'form', onSubmit: (event) => { event.preventDefault();
        handleClose(); }, }} >
        <DialogActions>
          <Card member={member} funOpen={handleClose} funAdd={addMem} funUpdate={updateMem}></Card>
        </DialogActions>
      </Dialog>
      <Box sx={{ flexGrow: 1, maxWidth: 500 }}>
        <Grid item xs={12} md={6}>
          <Typography sx={{ mt: 4, mb: 2 }} variant="h6" component="div">
            Members <GroupAddIcon className="item" onClick={() => handleClickOpen(null)}></GroupAddIcon>
          </Typography>
          <Demo>
            <List dense={dense}>
              {arrMembers.length > 0 && arrMembers.map(member => {
                return <>
                  <ListItem key={member.id}>
                    <ListItemAvatar>
                      <Avatar>
                        <FolderIcon onClick={() => handleClickOpen(member)} />
                      </Avatar>
                    </ListItemAvatar>
                    <ListItemText><span className="item">{member.lastName}</span><span className="item">{member.firstName}</span><span className="item">{member.phone}</span></ListItemText>
                    <IconButton edge="end" aria-label="delete">
                      <DeleteIcon onClick={() => { delMember(member.id) }} />
                    </IconButton>
                  </ListItem>
                </>
              })}
            </List>
          </Demo>
        </Grid>
      </Box>
    </div>
  </>)
}