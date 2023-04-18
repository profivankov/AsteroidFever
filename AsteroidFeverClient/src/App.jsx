import React, { useEffect, useState } from "react";
import axios from "axios";
import {
  Box,
  TextField,
  MenuItem,
  Button,
  Typography,
  InputAdornment,
  Select,
  FormControl,
  InputLabel,
  Stack,
} from "@mui/material";

import "./App.css";
import { deformAsteroid, hoverLogo } from "./other/animation";
import EarthAsteroid from "./components/EarthAsteroid";
import MeasuringUnits from "./components/MeasuringUnits";
import ImpactTierInfo from "./components/ImpactTierInfo";

const materialMap = {
  Unknown: 0,
  Ice: 1,
  Rock: 2,
  Iron: 3,
};

const maxTierValue = 5;

const App = () => {
  const [mass, setMass] = useState(0);
  const [speed, setSpeed] = useState(0);
  const [size, setSize] = useState(null);
  const [material, setMaterial] = useState(0);
  const [angle, setAngle] = useState(null);
  const [realismMode, setRealismMode] = useState(false);
  const [kineticEnergy, setKineticEnergy] = useState(null);
  const [impactTier, setImpactTier] = useState(null);

  const getImpactTier = (event) => {
    const requestData = realismMode
      ? {
          mass: mass,
          speed: speed,
          size: size,
          material: materialMap[material],
          angle: angle,
        }
      : {
          mass: mass,
          speed: speed,
        };
    event.preventDefault();
    axios
      .post(
        "https://asteroidfeverapi.azurewebsites.net/api/impact",
        requestData
      )
      .then((res) => {
        const { kineticEnergy, tierLevel } = res.data;
        setKineticEnergy(kineticEnergy);
        setImpactTier(tierLevel ? tierLevel : maxTierValue);
        deformAsteroid();
      })
      .catch((error) => {
        console.error("Error fetching data:", error);
      });
  };

  useEffect(() => {
    hoverLogo();
  }, []);

  const showResult = kineticEnergy;

  return (
    <>
      <Box className="App">
        <Typography variant="h2" className="neon-heading" id="asteroidTitle">
          ASTEROID FEVER
        </Typography>

        {showResult ? (
          <Box>
            <Stack spacing={4}>
              <Box width="300px">
                <ImpactTierInfo
                  kineticEnergy={kineticEnergy}
                  tierLevel={impactTier}
                />
              </Box>
              <Button
                variant="contained"
                color="primary"
                onClick={() => {
                  setKineticEnergy(null);
                  setImpactTier(null);
                }}
              >
                Restart
              </Button>
            </Stack>
          </Box>
        ) : (
          <>
            <Box className="input-container">
              <Box className="input-group">
                <TextField
                  type="number"
                  value={mass}
                  onChange={(e) => setMass(e.target.value)}
                  label="Mass"
                  variant="outlined"
                  margin="dense"
                />
                <TextField
                  type="number"
                  value={speed}
                  onChange={(e) => setSpeed(e.target.value)}
                  label="Speed"
                  variant="outlined"
                  margin="dense"
                />
              </Box>
              <MeasuringUnits />
            </Box>
            {realismMode && (
              <Box className="realism-inputs">
                <TextField
                  type="number"
                  value={size}
                  onChange={(e) => setSize(e.target.value)}
                  label="Size"
                  variant="outlined"
                  margin="dense"
                  InputProps={{
                    endAdornment: (
                      <InputAdornment position="end">m</InputAdornment>
                    ),
                  }}
                />
                <FormControl variant="outlined" margin="dense">
                  <InputLabel htmlFor="material">Material</InputLabel>
                  <Select
                    labelId="material-label"
                    id="material"
                    value={material}
                    onChange={(e) => setMaterial(e.target.value)}
                    label="Material"
                    defaultValue="Unknown"
                  >
                    <MenuItem value={0}>Unknown</MenuItem>
                    <MenuItem value={1}>Ice</MenuItem>
                    <MenuItem value={2}>Rock</MenuItem>
                    <MenuItem value={3}>Iron</MenuItem>
                  </Select>
                </FormControl>
                <TextField
                  type="number"
                  value={angle}
                  onChange={(e) => setAngle(e.target.value)}
                  label="Angle"
                  variant="outlined"
                  margin="dense"
                  InputProps={{
                    endAdornment: (
                      <InputAdornment position="end">rad</InputAdornment>
                    ),
                  }}
                />
              </Box>
            )}
            <Button variant="contained" color="primary" onClick={getImpactTier}>
              Destroy
            </Button>
            <Button
              variant="outlined"
              onClick={() => setRealismMode(!realismMode)}
            >
              {realismMode ? "Hide Realism Mode" : "Realism Mode"}
            </Button>
          </>
        )}
        <EarthAsteroid />
      </Box>
    </>
  );
};

export default App;
