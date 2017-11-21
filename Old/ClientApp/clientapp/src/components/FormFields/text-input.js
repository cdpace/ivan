import React from 'react';

export default(field) => {

    const {title, input, placeholder} = field;

    return (
        <div>
            <label>{title}</label>
            <input type="text" value={input} placeholder={placeholder} />
        </div>
    );

}