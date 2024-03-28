import { useEffect } from "react"
import { getPatientsPerDay, getCntNotVaccinated } from './statisticsSlice'
import { useDispatch, useSelector } from 'react-redux'
import * as React from 'react';
import Typography from '@mui/material/Typography';
import { LineChart } from '@mui/x-charts/LineChart';
import Divider from '@mui/material/Divider';
import './statistic.css'

export default function Statistics() {

  let dis = useDispatch();
  let cntNotVaccinated = useSelector(s => s.statistics.countNotVaccinated)
  let dataDaysInMonth = useSelector(s => s.statistics.patientsPerDay)
  const [daysInMonth, setDaysInMonth] = React.useState([]);


  useEffect(() => {
    dis(getCntNotVaccinated());
    dis(getPatientsPerDay())
    const day = new Date(new Date().getFullYear(), new Date().getMonth() + 1, 0).getDate()
    setDaysInMonth(Array.from({ length: day }, () => 0))
  }, [cntNotVaccinated, daysInMonth])

  return (<>
    <Typography className="cntNotVaccinated" variant="h5" gutterBottom>
      The number of members who are not vaccinated at all: {cntNotVaccinated}
    </Typography>
    <Divider />
    <Typography className="cntNotVaccinated" variant="h5" gutterBottom>
      Active patients for the current month:
    </Typography>
    <div className="activePatients"><LineChart
      xAxis={[{ data: dataDaysInMonth.map((day, index) => index + 1) }]}
      series={[
        {
          data: dataDaysInMonth,
        },
      ]}
      height={300}
      width={600}
      margin={{ left: 30, right: 30, top: 30, bottom: 30 }}
      grid={{ vertical: true, horizontal: true }}
    />
    </div>
  </>)
}