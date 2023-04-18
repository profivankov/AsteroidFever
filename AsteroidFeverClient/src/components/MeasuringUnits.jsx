import React from "react";

import { Box, MenuItem, Select, FormControl, InputLabel } from "@mui/material";

const MeasuringUnits = () => {
  return (
    <Box className="input-group">
      <FormControl variant="outlined" margin="dense">
        <InputLabel id="unit-label">Unit</InputLabel>
        <Select
          labelId="unit-label"
          value="kg"
          label="Unit"
          style={{ color: "rgba(0, 0, 0, 0.6)" }}
        >
          <MenuItem value="kg">kg</MenuItem>
        </Select>
      </FormControl>
      <FormControl variant="outlined" margin="dense">
        <InputLabel id="unit-label">Unit</InputLabel>
        <Select
          labelId="unit-label"
          value="m/s"
          label="Unit"
          style={{ color: "rgba(0, 0, 0, 0.6)" }}
        >
          <MenuItem value="m/s">m/s</MenuItem>
        </Select>
      </FormControl>
    </Box>
  );
};

export default MeasuringUnits;
