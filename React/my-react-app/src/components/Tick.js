import React from 'react';




function Tick() {
    const element = (
        <div>
            <p>Current time is {new Date().toLocaleTimeString()}.</p>
        </div>
    );

    }
setInterval(Tick, 1000);

  
export default Tick;