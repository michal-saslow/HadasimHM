import * as React from 'react';
import { useEffect } from "react"
import { getVaccinationsForMember, getVaccinations } from './cardSlice'
import { useDispatch, useSelector } from 'react-redux'
import Box from '@mui/material/Box';
import FormControl from '@mui/material/FormControl';
import Input from '@mui/material/Input';
import InputLabel from '@mui/material/InputLabel';
import KeyboardArrowRightOutlinedIcon from '@mui/icons-material/KeyboardArrowRightOutlined';
import KeyboardArrowDownOutlinedIcon from '@mui/icons-material/KeyboardArrowDownOutlined';
import SendIcon from '@mui/icons-material/Send';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import LibraryAddOutlinedIcon from '@mui/icons-material/LibraryAddOutlined';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import { styled } from '@mui/material/styles';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import Alert from '@mui/material/Alert';
import './card.css'

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: 'center',
  color: theme.palette.text.secondary,
}));

export default function Card(props) {
  
  let currentMember = props.member
  let dis = useDispatch();
  let arrVaccinationsFroMember = useSelector(s => s.card.allVaccinationfromMember)
  let arrVaccinations = useSelector(s => s.card.allVaccination)
  const [openListOfVaccinat, setOpenListOfVaccinat] = React.useState(true)
  const [openInputToAdd, setOpenInputToAdd] = React.useState(false)
  const [currentVaccination, setCurrentVaccination] = React.useState({
    vaccinationId: 0,
    MemberId: currentMember && currentMember.id,
    date: new Date()
  })
  const [memberWithId, setMemberId] = React.useState({
    id: currentMember && currentMember.id,
    member: {
      firstName: currentMember && currentMember.firstName,
      lastName: currentMember && currentMember.lastName,
      identity: currentMember && currentMember.identity,
      cityId: currentMember && currentMember.city.id,
      city: {
        name: currentMember && currentMember.city.name,
        address: currentMember && currentMember.city.address,
        houseNumber: currentMember && currentMember.city.houseNumber
      },
      dateOfBirth: currentMember ? currentMember.dateOfBirth : Date,
      phone: currentMember && currentMember.phone,
      cellPhone: currentMember && currentMember.cellPhone,
      dateOfIllness: currentMember ? currentMember.dateOfIllness : Date,
      dateOfRecovery: currentMember ? currentMember.dateOfRecovery : Date,
      profileImage: currentMember && currentMember.profileImage,
      vfms: arrVaccinationsFroMember ? arrVaccinationsFroMember : []
    }
  })

  useEffect(() => {
    const fetchData = async () => {
      if (currentMember != null) {
        await dis(getVaccinationsForMember(currentMember.id));
      } else {
        setMemberId({ ...memberWithId, member: { ...memberWithId.member, vfms: [] } })
      }
      dis(getVaccinations())
    };

    fetchData();
  }, [currentMember]);

  useEffect(() => {
    if (currentMember != null) {
      setMemberId(prevState => ({
        ...prevState,
        member: { ...prevState.member, vfms: arrVaccinationsFroMember }
      }));
    }
  }, [arrVaccinationsFroMember]);

  const deleteOneVaccination = (id) => {
    let copy = [...memberWithId.member.vfms]
    let index = memberWithId.member.vfms.findIndex(x => x.id == id)
    copy.splice(index, 1)
    setMemberId({ ...memberWithId, member: { ...memberWithId.member, vfms: copy } })
  }

  const saveChanges = () => {
    if (currentMember == null) {
      props.funAdd(memberWithId.member)
    }
    else {
      props.funUpdate(memberWithId)
    }
    props.funOpen()
  }

  const addOneVaccination = () => {
    setOpenInputToAdd(false)
    const copy = [...memberWithId.member.vfms]
    copy.push(currentVaccination)
    setMemberId({ ...memberWithId, member: { ...memberWithId.member, vfms: copy } })
  }

  const handleFileUpload = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => {
      const imageUrl = e.target.result;
      setMemberId({ ...memberWithId, member: { ...memberWithId.member, profileImage: imageUrl } })
    };
    reader.readAsDataURL(file);
  };

  return (<>
    <Box component="form" sx={{ '& > :not(style)': { m: 1 }, }} noValidate autoComplete="off" >
      <div className='divImg'>
        {memberWithId.member.profileImage && <img className='img' src={memberWithId.member.profileImage} alt="Uploaded Image" />}
        {memberWithId.member.profileImage == null && <input type="file" accept="image/*" onChange={handleFileUpload} />}
      </div>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">Name</InputLabel>
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, firstName: e.target.value } })} defaultValue={currentMember && currentMember.firstName} />
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">LastName</InputLabel>
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, lastName: e.target.value } })} defaultValue={currentMember && currentMember.lastName} />
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">Phone</InputLabel>
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, phone: e.target.value } })} defaultValue={currentMember && currentMember.phone} />
        {memberWithId.member.phone != null && (memberWithId.member.phone.length != 10 && memberWithId.member.phone.length != 9) && <Alert severity="error">phone must be 9/10 digits long</Alert>}
        {memberWithId.member.phone != null && (memberWithId.member.phone[0] != 0) && <Alert severity="error">phone must start with the digit 0</Alert>}
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">Cellphone</InputLabel>
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, cellPhone: e.target.value } })} defaultValue={currentMember && currentMember.cellPhone} />
        {memberWithId.member.cellPhone != null && (memberWithId.member.cellPhone.length != 10 && memberWithId.member.cellPhone.length != 9) && <Alert severity="error">cellPhone must be 9/10 digits long</Alert>}
        {memberWithId.member.cellPhone != null && (memberWithId.member.cellPhone[0] != 0 || memberWithId.member.cellPhone[1] != 5) && <Alert severity="error">cellPhone must start with the digits 05</Alert>}
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">City</InputLabel>
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, city: { ...memberWithId.member.city, name: e.target.value } } })} defaultValue={currentMember && currentMember.city.name} />
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">Street</InputLabel>
        <Input className='street' onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, city: { ...memberWithId.member.city, address: e.target.value } } })} id="component-simple" defaultValue={currentMember && currentMember.city.address} />
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple" >HouseNumber</InputLabel>
        <Input className='number' onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, city: { ...memberWithId.member.city, houseNumber: e.target.value } } })} id="component-simple" type='number' defaultValue={currentMember && currentMember.city.houseNumber} />
      </FormControl>
      <FormControl variant="standard">
        <InputLabel htmlFor="component-simple">Identity</InputLabel>
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, identity: e.target.value } })} defaultValue={currentMember && currentMember.identity} />
        {memberWithId.member.identity != null && memberWithId.member.identity.length != 9 && <Alert severity="error">ID card must contain 9 digits</Alert>}
      </FormControl>
      <FormControl variant="standard">
        <InputLabel style={{ top: '-20px', fontSize: '12px' }}>DateOfBirth</InputLabel>
        <br />
        {currentMember && currentMember.dateOfBirth}
        <Input className='ss' onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, dateOfBirth: e.target.value } })} id="component-simple" type='date' defaultValue={currentMember && currentMember.dateOfBirth} />
        {memberWithId.member.dateOfBirth != null && Date.parse(memberWithId.member.dateOfBirth) > Date.now() && <Alert severity="error">Date of birth must be less than current date</Alert>}
      </FormControl>
      <FormControl variant="standard">
        <InputLabel style={{ position: 'absolute', top: '-20px', fontSize: '12px' }}>DateOfIllness</InputLabel>
        <br />
        {currentMember && currentMember.dateOfIllness}
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, dateOfIllness: e.target.value } })} type='date' defaultValue={currentMember && currentMember.dateOfIllness} />
        {memberWithId.member.dateOfIllness != null && Date.parse(memberWithId.member.dateOfIllness) > Date.now() && <Alert severity="error">Date of illness must be less than current date</Alert>}
      </FormControl>
      <FormControl variant="standard">
        <InputLabel style={{ position: 'absolute', top: '-20px', fontSize: '12px' }}>DateOfRecovery</InputLabel>
        <br />
        {currentMember && currentMember.dateOfRecovery}
        <Input id="component-simple" onChange={(e) => setMemberId({ ...memberWithId, member: { ...memberWithId.member, dateOfRecovery: e.target.value } })} type='date' defaultValue={currentMember && currentMember.dateOfRecovery} />
        {memberWithId.member.dateOfIllness != null && Date.parse(memberWithId.member.dateOfRecovery) > Date.now() && <Alert severity="error">Date of recovery must be less than current date</Alert>}
        {memberWithId.member.dateOfIllness != null && memberWithId.member.dateOfRecovery != null && memberWithId.member.dateOfIllness > memberWithId.member.dateOfRecovery && <Alert severity="error">Your recovery date must be greater than your illness date</Alert>}
        {memberWithId.member.dateOfIllness == null && memberWithId.dateOfRecovery != null && <Alert severity="error">Invalid date of recovery without date of illness</Alert>}
      </FormControl>
      <br />
      <div className='vaccination'>
        {!openListOfVaccinat && <KeyboardArrowRightOutlinedIcon onClick={() => setOpenListOfVaccinat(true)}></KeyboardArrowRightOutlinedIcon>}
        {openListOfVaccinat && <KeyboardArrowDownOutlinedIcon onClick={() => setOpenListOfVaccinat(false)}></KeyboardArrowDownOutlinedIcon>}
        <span>my vaccinations</span>
      </div>
      <Box sx={{ width: '50%' }}>
        {openListOfVaccinat && <Stack spacing={1}>
          {memberWithId.member.vfms.length > 0 && memberWithId.member.vfms.map(v => {
            return <div className='vaccination'>
              <DeleteOutlinedIcon onClick={() => deleteOneVaccination(v.id)}></DeleteOutlinedIcon>
              <Item><span className="item">{arrVaccinations && (arrVaccinations.find(item => item.id === v.vaccinationId)?.manufacturerName)}</span><span className="item"> {v.date} </span></Item>
            </div>
          })}
          <span className='vaccination'>
            {arrVaccinationsFroMember.length < 4 && memberWithId.member.vfms.length < 4 && <LibraryAddOutlinedIcon onClick={() => setOpenInputToAdd(true)}></LibraryAddOutlinedIcon>}
            {openInputToAdd && <span className="vaccination" >
              <input className="item" type='date' value={currentMember && currentMember.date} onChange={(e) => setCurrentVaccination({ ...currentVaccination, date: e.target.value })}></input>
              <Box className="item" sx={{ minWidth: 120 }}>
                <FormControl fullWidth>
                  <InputLabel id="demo-simple-select-label">ManufacturerName</InputLabel>
                  <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    label="ManufacturerName"
                    value={currentVaccination.vaccinationId}
                    onChange={(e) => setCurrentVaccination({ ...currentVaccination, vaccinationId: e.target.value })}
                  >
                    {arrVaccinations.length > 0 && arrVaccinations.map(vac => { return <MenuItem value={vac.id}>{vac.manufacturerName}</MenuItem> })}
                  </Select>
                </FormControl>
              </Box>
              <SendIcon className="item" onClick={addOneVaccination} /></span>}
          </span>
        </Stack>}
      </Box>
      <Button variant="contained" onClick={saveChanges} endIcon={<SendIcon />}>
        save changes
      </Button>
    </Box>
  </>)
}